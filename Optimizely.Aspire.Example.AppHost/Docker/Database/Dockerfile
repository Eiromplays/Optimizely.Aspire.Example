FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y

ARG DB_DIRECTORY
ENV DB_DIRECTORY=$DB_DIRECTORY

ARG DB_NAME
ENV DB_NAME=$DB_NAME

RUN --mount=type=secret,id=db-password \
    export SA_PASSWORD=$(cat /run/secrets/db-password)

USER root

WORKDIR /src
COPY . .
RUN chmod +x /src/configure-db.sh
RUN chmod +x /src/entrypoint.sh

USER mssql

ENTRYPOINT ["/src/entrypoint.sh"]