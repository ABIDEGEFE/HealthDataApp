#!bin/bash

resourceGroup="appRG"
planName="healthAppPlan"
appName="healthApp"
connectionString='Server=tcp:healthserverdb.database.windows.net,1433;Initial Catalog=healthDB;Persist Securi
ty Info=False;User ID=Abinet;Password=ABne665506**;MultipleActiveResultSets=False;Encrypt=True;TrustServerCert
ificate=False;Connection Timeout=30;'

# create the service plan to run web app

az appservice plan create  \
  --name $planName \
  --resource-group $resourceGroup 
  --sku B1 --is-linux

# create web app 

az webapp create \
   --resource-group $resourceGroup \
   --plan $planName \
   --name $appName \
   --runtime "DOTNETCORE|8.0"

# connect the app with the database, use your own connection string

az webapp config connection-string set \
   --resource-group $resourceGroup\
   --name $appName\
   --settings DefaultConnection= $connectionString\
   --connection-string-type SQLServer

# configure app setting in azure app service

az webapp config appsettings set \
   --name $appName \
   --resource-group $resourceGroup \
   --settings ASPNETCORE_ENVIRONMENT="Production"