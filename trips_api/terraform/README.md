# Trips Solution Terraform

This Terraform project defines, configures and deploys the infrastructure's desire state for the Trips API solution. 

It uses the Terraform Workspace concept that allows to deploy to multiple environments (keeping different states) but using the same configuration. More information [here](https://learn.hashicorp.com/tutorials/terraform/organize-configuration) 

## Configuration Instruccions
1. Run a Terraform Init in this folder
1. Execute  `terraform workspace new dev` and then terraform init
1. Execute  `terraform workspace new prod` and then terraform init
1. When applying configurations in **dev** use 'terraform apply -var-file=dev.tfvars'
1. When applying configurations in **prod** use 'terraform apply -var-file=prod.tfvars'
1. When switching btw workspaces use: `terraform workspace select dev`

In Prod ready conditions, all secrets and configurations that are output from applying the changes must the pushed to respective KevyVaults, config server and between dependant components settings. For simplicity this is just deploying the basic independent items and output the main keys in the console's output.