# build-image:
# 	docker build -t conclave .

# run-local: build-image server

# server:
# 	docker run --rm -p 3000:3000 -e DEBUG=express:* conclave npm start

build:
	@npm run build
run:
	@npm run local

clean:
	@rm -rf public/js/
	@-sudo fuser -kf 3000/tcp