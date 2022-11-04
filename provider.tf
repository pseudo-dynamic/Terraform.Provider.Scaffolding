terraform {
  required_providers {
    scaffolding = {
      #   source  = "registry.terraform.io/pseudo-dynamic/scaffolding"
      // Because we use terraform.tfrc we cannot use the fully-qualified provider name
      source  = "scaffolding"
      version = "0.1.0"
    }
  }
}

resource "scaffolding_my_resource" "default" {
  sample_attribute = "Hello from resource"
}

data "scaffolding_my_data_source" "default" {
  sample_attribute = scaffolding_my_resource.default.computed_attribute
}

output "my_resource" {
  value = {
    sample_attribute   = scaffolding_my_resource.default.sample_attribute
    computed_attribute = scaffolding_my_resource.default.computed_attribute
  }
}

output "my_data_source" {
  value = {
    sample_attribute   = data.scaffolding_my_data_source.default.sample_attribute
    computed_attribute = data.scaffolding_my_data_source.default.computed_attribute
  }
}
