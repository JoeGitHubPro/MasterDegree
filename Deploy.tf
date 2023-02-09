provider "azurerm" {
  version = "2.0"
}

resource "azurerm_resource_group" "example" {
  name     = "example-rg"
  location = "westus"
}

resource "azurerm_sql_server" "example" {
  name                         = "example-sql-server"
  resource_group_name         = azurerm_resource_group.example.name
  location                    = azurerm_resource_group.example.location
  version                     = "12.0"
  administrator_login         = "sqladmin"
  administrator_login_password = "P@ssw0rd!"
}

resource "azurerm_sql_database" "example" {
  name                             = "example-db"
  resource_group_name             = azurerm_resource_group.example.name
  server_name                     = azurerm_sql_server.example.name
  create_mode                     = "Default"
  collation                       = "SQL_Latin1_General_CP1_CI_AS"
  requested_service_objective_name = "S0"
}

resource "azurerm_app_service_plan" "example" {
  name                = "example-asp"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_web_app" "example" {
  name                = "example-web-app"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  app_service_plan_id = azurerm_app_service_plan.example.id

  site_config {
    dotnet_framework_version = "v4.7"
  }

  connection_string {
    name  = "example-db"
    type  = "SQLAzure"
    value = "Server=tcp:${azurerm_sql_server.example.fully_qualified_domain_name};Initial Catalog=${azurerm_sql_database.example.name};User ID=${azurerm_sql_server.example.administrator_login};Password=${azurerm_sql_server.example.administrator_login_password};"
    }
}
