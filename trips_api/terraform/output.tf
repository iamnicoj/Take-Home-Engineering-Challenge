output "instrumentation_key" {
  value = azurerm_application_insights.main_apps_insights.instrumentation_key
}

output "app_id" {
  value = azurerm_application_insights.main_apps_insights.app_id
}
