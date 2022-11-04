# Terraform.Provider.Scaffolding

This project is inspired by hashicorp/terraform-provider-scaffolding and provides you a minimal setup using [PseudoDynamic.Terraform.Toolset](https://github.com/pseudo-dynamic/PseudoDynamic.Terraform.Toolset).

## Requirements

- dotnet CLI + .NET 6.0 SDK
- terraform (TODO: estimate lowest supported version, but v1.2.8+ should be fine)

## Use Provider

Assuming your workdir is this repository root directory:

1. Run `dotnet build`
2. Set environment variable `TF_CLI_CONFIG_FILE=Terraform.Provider.Scaffolding/terraform.tfrc`
3. Run `terraform validate`, `terraform plan`, `terraform apply` or `terraform destroy`

# Generate Provider Documentation

> :exclamation: Currently not supported, see below.

By following the guide of [go-modules-by-example](https://github.com/go-modules-by-example/index/blob/master/010_tools/README.md) you need to follow these steps

- `export GOBIN="<absolute-path-to-repo>/bin"` (Bash)
- `export PATH=$GOBIN:$PATH` (Bash)
- `go install github.com/hashicorp/terraform-plugin-docs/cmd/tfplugindocs`
- `tfplugindocs generate`

> :x: At the moment `tfplugindocs` does not support external provider executables. The `go build` procedure is a fixed component of `tfplugindocs generate`. But we generated our own terraform-provider-scaffold binary, so this needs to be fixed at side of `tfplugindocs`. :D

# Provider Development

Read [here](https://github.com/pseudo-dynamic/PseudoDynamic.Terraform.Toolset) to get more familiar with [PseudoDynamic.Terraform.Toolset](https://github.com/pseudo-dynamic/PseudoDynamic.Terraform.Toolset).