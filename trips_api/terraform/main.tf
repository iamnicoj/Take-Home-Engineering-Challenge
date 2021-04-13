resource "azurerm_resource_group" "main_resource_group" {
  name     = format("%s%s",var.prefix,"_rg_nicotripsapi")
  location = var.region
}

# App Insights
resource "azurerm_application_insights" "main_apps_insights" {
  name                = format("%s%s",var.prefix,"_ai_nicotripsapiappinsights")
  location            = azurerm_resource_group.main_resource_group.location
  resource_group_name = azurerm_resource_group.main_resource_group.name
  application_type    = "web"
}

# SQL SERVER
resource "azurerm_sql_server" "tripsdbserver" {
  name                         = format("%s%s",var.prefix,"nicotripsanalyticsapidb")
  resource_group_name          = azurerm_resource_group.main_resource_group.name
  location                     = var.region
  version                      = "12.0"
  administrator_login          = "nicoadmin"
  administrator_login_password = "4-v3ry-53cr37-p455w0rd"
}

resource "azurerm_storage_account" "tripssa" {
  name                     = format("%s%s",var.prefix,"nicotripdbsa")
  resource_group_name      = azurerm_resource_group.main_resource_group.name
  location                 = azurerm_resource_group.main_resource_group.location
  account_tier             = "Standard"
  account_replication_type = "LRS"
}

resource "azurerm_sql_database" "tripsdb" {
  name                 = format("%s%s",var.prefix,"nicotripsdb")
  resource_group_name = azurerm_resource_group.main_resource_group.name
  location            = var.region
  server_name         = azurerm_sql_server.tripsdbserver.name
}

# App Service 
resource "azurerm_app_service_plan" "tripsappsp" {
  name                 = format("%s%s",var.prefix,"nicotripsappserviceplan")
  location            = azurerm_resource_group.main_resource_group.location
  resource_group_name = azurerm_resource_group.main_resource_group.name
  kind                = "Linux"
  reserved            = true

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "tripsappservice" {
  name                = format("%s%s",var.prefix,"nicotripsappservice")
  location            = azurerm_resource_group.main_resource_group.location
  resource_group_name = azurerm_resource_group.main_resource_group.name
  app_service_plan_id = azurerm_app_service_plan.tripsappsp.id

  site_config {
    dotnet_framework_version = "v5.0"
    scm_type                 = "LocalGit"
    always_on                = true
  }

  app_settings = {
    "InstrumentationKey" = "7f44b7d1-c549-4967-80f7-135b4d822b24"
  }

  connection_string {
    name  = "TripApiDB"
    type  = "SQLServer"
    value = "Server=some-server.mydomain.com;Integrated Security=SSPI"
  }
}