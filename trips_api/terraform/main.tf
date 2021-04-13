resource "azurerm_resource_group" "main_resource_group" {
  name     = format("%s%s",var.prefix,"_rg_nicotripsapi")
  location = var.region
}

resource "azurerm_application_insights" "main_apps_insights" {
  name                = format("%s%s",var.prefix,"_ai_nicotripsapiappinsights")
  location            = azurerm_resource_group.main_resource_group.location
  resource_group_name = azurerm_resource_group.main_resource_group.name
  application_type    = "web"
}


