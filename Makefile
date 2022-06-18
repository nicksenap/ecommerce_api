MIGRATE_MSG ?= "initialSetup"


helloWorld:
	echo 'Hello'

docker.pg.up:
	docker-compose -f docker-compose-pg-only.yml up -d

docker.pg.down:
	docker-compose -f docker-compose-pg-only.yml down -d

dotnet.migrate:
	dotnet ef migrations add $(MIGRATE_MSG)
	
dotnet.run: docker.pg.up
	dotnet run --project ./ecommerce_api.csproj
	
clearUp:
	docker.pg.down