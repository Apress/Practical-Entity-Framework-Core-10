# Listing 13-3: The Orchestrator Workflow YAML

This is the orchestrator workflow

## The YAML

Workflows are done in YAML, and each one is triggered in sequence by this workflow.

```yml
name: Inventory Manager Build and Deploy Orchestrator

on:
  push:
    branches:
      - main

permissions:
  id-token: write
  contents: read

jobs:
  build:
    uses: ./.github/workflows/build-and-test.yml

  publish_image:
    needs: build
    uses: ./.github/workflows/publish-image.yml
    secrets:
      GHCR_TOKEN: ${{ secrets.GHCR_TOKEN }}

  deploy:
    needs: publish_image
    uses: ./.github/workflows/deploy.yml
    secrets: inherit
```  

As you can see, there isn't much to this file, and it simply runs the build, creates and publishes the image, then the runs the deployment in series.