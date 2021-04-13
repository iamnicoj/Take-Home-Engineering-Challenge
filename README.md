# Architecture solution 

I implemented a high-quality solution deployable as a dotnet 5, c#9 WebApi that uses an Azure SQL Database as a storage backend. The API exposes a dynamic, extensible, and generic queryable mechanism that allows consumers to easily get advanced insights over data on NYC’s yellow/green cabs and for-hire vehicles, with a variety of filters (a feature that can potentially be used in any other city). I implemented a broad set of crucial production-like features, including:

* Organizing the solution structure, folders, and namespaces for a
high level of abstraction and maintainability

* Decoupling inner and outer dependencies through the use of asp.net dependency injection

* Decouple Controllers, Action Filters, Services, Models, DTOs,
Enums, Repositories, Exceptions, and Telemetry Services

* I implemented a unit-test solution to test all core services that
process user queries, leveraging a state-of-the-art mocking in-memory database
as an injectable repository service to completely decouple the tests from the
underlying services. 

* Robust and standardized exception handling injected as a WebApi
global service.

* I implemented manual exploratory testin using the Clien REST VsCode extension. Find the test [here](trips_api/api/src/Docs/TripsTests.http) and set of usefull filter combinations [here](trips_api/api/src/.vscode/settings.json)

* I built a key feature to let an ‘X-Request-ID’ header that allows
for telemetry and tracking purposes. If not supplied, it auto-generates it and
returns it as a response header.

* I created a full telemetry service for critical metrics, requests,
dependencies, and exceptions.

* Custom Tracing for key query events that logs dynamic query
objects as a custom dimension on the custom event table within App insights.

* Sophisticated implementation of a model-first data model and
repository services. No need for any additional SQL artifacts - like store
procedures, indexes, or triggers.

* The data-schema model is a fully denormalized table with an
augmented schema - including columns like weekday, boroughs and zones, and all
sorts of range bins —sometimes called a class interval- to empower the consumer
to explore an excellent tool for statistical analysis and creating histograms. 

* I created a polished dev-tests data seed mechanism that allows for
any developer to get hundreds of thousands of records of actual data loaded in
their dev environment even before they start coding the first line.

* Infrastructure as Code solution for multi-environment deployments
(Dev/Prod) for key components:

    * App services

    * Sql Database

    * App Insights

* Used a NuGet packaged called TinyCvsMapper to create a dynamic model to ready and map any type of csv structure into the Trips data model

* Finally, I created the basic constructs to build a data ingestion
pipeline which features:


* I developed a Python crawler (using Scrapy) that creates a json
file with the list of all available and relevant .csv files from the official NYC
city page.

* I developed another Python script that downloads the file from
their original AWS storage location, splits each into a configurable number of
smaller files (X rows), and uploads them into an azure storage.

* I created a .net 5 C# Azure function with a Blob trigger that runs
once it detects one of these CSV files got uploaded, and it pushes the rows
into the SQL database. At this point, I found what I believe is a bug in the
Azure function blob trigger function for .net 5 construct and had to stop as I
ran out of time. I did raise the issue in GitHub here in case you are
interested. So basically, no luck at loading all the hundreds of thousands of
records.


# Why did I choose this approach
* My main goal was to maximize the little time I had to enable as many Prod-Like features as possible. I knew choosing asp.net with entity framework model first and Linq query mode was going to allow me to hit the ground running fast and focus in refactoring, abstracting, testing . I also had a clear vision of the data model (de-normalizing and augmenting the model) and knew I needed a powerful way to be able to query on any dimensions without having the limitations when querying a document type of database or the partition strategy.
* Additional, I used Python for crawling, spliting, downloading and uploading files, as it is the perfect tool for every day automation tasks.
* Terraform as my defacto option for automating infraestructure tasks and have a consiste way of planning and verifying the changes before its apply them.
# What I would have done different or would've wanted to explore in this scenario:
* Proper AuthN/AuthZ, keys, managed identity and other security aspects.
* A graphQL can make a lot of sense to enable a fully searchable dynamic model 
* An in-memory Cache to preload and hold the most common used queries
* A proper data ingestion process, probably using Azure Batch to manage and process all the huge files and a tuned Bulk Insert SQL mechanism
* It can also make sense to implement a Data Lake storage option to enable an alternative Bid data/ data warehouse type of analytics in top of the monthly millions of records 

# Known Issues
* You can only query by one service provider at a time (yellow, green, FHV)
* I open a gh issue on the azure functions .net blob trigger https://github.com/Azure/Azure-Functions/issues/1881 that blocked me to enable full data ingestion
* This soluction actually doesn't have any security features.

# Local Dev Setup instructions
Please review each project README.md