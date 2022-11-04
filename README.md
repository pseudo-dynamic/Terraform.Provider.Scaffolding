# Terraform.Provider.Scaffolding

This project is inspired by https://github.com/hashicorp/terraform-provider-scaffolding and provides you a minimal setup using [PseudoDynamic.Terraform.Toolset](https://github.com/pseudo-dynamic/PseudoDynamic.Terraform.Toolset).

## Requirements

- dotnet CLI + .NET 6.0 SDK
- terraform (TODO: estimate lowest supported version, but v1.2.8+ should be fine)

## Use Provider

Assuming your workdir is this repository root directory:

1. Run `dotnet build`
2. Set environment variable `TF_CLI_CONFIG_FILE=Terraform.Provider.Scaffolding/terraform.tfrc`
3. Run `terraform validate`, `terraform plan`, `terraform apply` or `terraform destroy`

# Provider Development

Read [here](https://github.com/pseudo-dynamic/PseudoDynamic.Terraform.Toolset) to get more familiar with [PseudoDynamic.Terraform.Toolset](https://github.com/pseudo-dynamic/PseudoDynamic.Terraform.Toolset).