# Listing 13-5: The publish step

In this workflow, the project is packaged and pushed to your container registry at GitHub.

## The yaml

```yml
# Publish the App as a Docker Image

on:
  workflow_call:
    secrets:
      GHCR_TOKEN:
        required: true

jobs:
  publish:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v4

      - name: Build Docker Images
        run: |
          repo=$(echo "${{ github.repository }}" | tr '[:upper:]' '[:lower:]')
          docker build -t ghcr.io/$repo/invmgrweb:${{ github.sha }} .
          docker tag ghcr.io/$repo/invmgrweb:${{ github.sha }} ghcr.io/$repo/invmgrweb:latest
      
      - name: Login to GHCR
        run: echo $CR_PAT | docker login ghcr.io -u ${{ github.actor }} --password-stdin
        env:
          CR_PAT: ${{ secrets.GHCR_TOKEN }}

      - name: Push Docker Images
        run: |
          repo=$(echo "${{ github.repository }}" | tr '[:upper:]' '[:lower:]')
          docker push ghcr.io/$repo/invmgrweb:${{ github.sha }}
          docker push ghcr.io/$repo/invmgrweb:latest
        env:
          CR_PAT: ${{ secrets.GHCR_TOKEN }}
```  

Notice that this first checks out the code, then builds the image.  Next it logs in to the GHCR, then pushes the image to the ghcr.
Also notice that it publishes the tag for the run plus the "latest" tag.  When using a real production solution, you might not want to use "latest" - instead you might consider something like an actual release number and then use that on the deployment step

>**Note:** it is important to remember that everything from this chapter that involves deployment is done in the simplest way possible, not necessarily the best way possible.  Also, you don't have to use GHCR, you can use ACR or whatever the container registry is at AWS or GCP, or you can even use Docker Hub itself.