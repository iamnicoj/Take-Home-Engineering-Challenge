import scrapy


class NycDataSpider(scrapy.Spider):
    name = "nycdata"

    def start_requests(self):
        urls = [
            'https://www1.nyc.gov/site/tlc/about/tlc-trip-record-data.page'
        ]
        for url in urls:
            yield scrapy.Request(url=url, callback=self.parse)

    def parse(self, response):
        for csv_url in response.xpath('//a[contains(@href, ".csv")]/@href').getall():
            yield {
                'file': csv_url
            }