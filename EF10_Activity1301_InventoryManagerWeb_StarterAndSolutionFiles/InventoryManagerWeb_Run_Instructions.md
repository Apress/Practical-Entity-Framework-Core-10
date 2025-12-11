# InventoryManagerWeb with SQL Server – Docker Instructions

This guide explains how to run the **InventoryManagerWeb** project with SQL Server using Docker.  
You have two options: using **Docker Compose** for a single command setup, or running the containers manually.

---

## Option 1: Run with Docker Compose

1. From the folder that contains both the `docker-compose.yml` file and the `Dockerfile`, run:

   ```bash
   docker compose up -d --build
   ```

   - `up` starts the containers defined in the `docker-compose.yml` file.
   - `-d` runs them in detached mode so your terminal is not locked.
   - `--build` ensures your web application is rebuilt from the Dockerfile.

2. Check the logs for SQL Server to verify it is ready. Run:

   ```bash
   docker compose logs -f sqlserver
   ```

   Wait until you see lines similar to:

   ```
   Parallel redo is started for database 'InventoryManagerDB1301' with worker pool size [2].
   Parallel redo is shutdown for database 'InventoryManagerDB1301' with worker pool size [2].
   ```

   Once these appear, SsQL Server has completed recovery and the ite will be accessible.

3. Open your browser and go to:

   - http://localhost:8080  
   - or http://localhost:8081

---

## Option 2: Run Manually

If you do not want to use Docker Compose, you can run the containers manually.

### Step 1: Create a network (only needs to be done once)

```bash
docker network create invmgrnet
```

### Step 2: Run SQL Server container (if you already have one running, skip to step 3)

If you do not already have a SQL Server container running:

>**Note:** Volume mounts `-v ...` are optional.  If you want to use them, make sure you have a folder in place with the path stated. If not, run the command without the volumes

#### With Volumes for persistence

```bash
docker run -d --name pef10_sql --network invmgrnet   -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password#123!" -p 1433:1433   -v C:/ContainerStorageVolumes/SQLServer2022_CH13/backup:/var/opt/mssql/backup   -v C:/ContainerStorageVolumes/SQLServer2022_CH13/data:/var/opt/mssql/data   -v C:/ContainerStorageVolumes/SQLServer2022_CH13/log:/var/opt/mssql/log   -v C:/ContainerStorageVolumes/SQLServer2022_CH13/secrets:/var/opt/mssql/secrets   mcr.microsoft.com/mssql/server:2022-latest
```

#### Without Volumes (data is lost if container is deleted)

```bash
docker run -d --name pef10_sql --network invmgrnet   -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password#123!" -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest
```

### Step 3: Add existing SQL container to the network (Skip this step if you did step 2)

If your SQL container is already running outside of this setup, attach it to the network:

```bash
docker network connect invmgrnet pef10_sql
```

### Step 4: Build and run the InventoryManagerWeb container

Build the web app image:

```bash
docker build -t inventorymanagerweb:dev .
```

Run the container:

>**Note:** Your password has to match the password for your sql container.

```bash
docker run -d --name invmgrweb --network invmgrnet   -p 8080:8080 -p 8081:8081   -e "ConnectionStrings__InventoryDbConnection=Server=pef10_sql;Database=InventoryManagerDB1301;User Id=sa;Password=Password#123!;TrustServerCertificate=True;MultipleActiveResultSets=true"   -e "ConnectionStrings__InventoryManagerIdentityDB=Server=pef10_sql;Database=InventoryManagerIdentityDB1301;User Id=sa;Password=Password#123!;TrustServerCertificate=True;MultipleActiveResultSets=true"   inventorymanagerweb:dev
```

### Step 5: Verify SQL Server readiness

Check logs:

```bash
docker logs -f pef10_sql
```

Wait until you see something like:

```text
Parallel redo is started for database 'InventoryManagerDB1301' with worker pool size [2].
Parallel redo is shutdown for database 'InventoryManagerDB1301' with worker pool size [2].
```

or

```text
SQL Server is ready
```  

At that point, you can browse to:

- http://localhost:8080  
- or http://localhost:8081

---

## Summary

- Use `docker compose up -d --build` for the easiest setup.  
- Or run SQL Server and the web app manually with `docker run`.  
- Always wait until SQL Server has finished recovery before accessing the web app.
