-- CREATE Syntax DLL
/*CREATE DATABASE simpleBank
    WITH
    OWNER = postgres -- default
    ENCODING = 'UTF8'
    LOCALE_PROVIDER = 'libc'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;*/

CREATE TABLE "account" (
    account_id BIGSERIAL,
    agency varchar(10) NOT NULL,
    number varchar(14) NOT NULL UNIQUE,
    starting_capital numeric(16, 2) NOT NULL DEFAULT 0.00,
    balance numeric(16, 2) NOT NULL DEFAULT 0.00,
    created_at DATE NOT NULL DEFAULT NOW(),
    updated_at DAtE NOT NULL DEFAULT NOW(),
    deletedAt DATE DEFAULT NULL
);

CREATE TABLE "user" (
    user_id BIGSERIAL,
    email varchar(100) NOT NULL UNIQUE,
    PASSWORD text DEFAULT NULL,
    account_id bigint UNIQUE,
    created_at DATE NOT NULL DEFAULT NOW(),
    updated_at DAtE NOT NULL DEFAULT NOW(),
    deletedAt DATE DEFAULT NULL
);

CREATE TABLE "person" (
    person_id BIGSERIAL,
    name varchar(70) NOT NULL,
    last_name varchar(70) NOT NULL,
    tax_id varchar(14) NOT NULL UNIQUE,
    birthday DATE NOT NULL,
    user_id bigint UNIQUE,
    created_at DATE NOT NULL DEFAULT NOW(),
    updated_at DAtE NOT NULL DEFAULT NOW(),
    deletedAt DATE DEFAULT NULL
);

CREATE TYPE EnumTransactionType AS ENUM ('Pix', 'Transference', 'TED', 'DOC');

CREATE TABLE "transactions" (
    transaction_id BIGSERIAL,
    date DATE NOT NULL DEFAULT NOW(),
    account_sender bigint NOT NULL,
    account_receiver bigint NOT NULL,
    transaction_value numeric(16, 2) NOT NULL,
    transaction_type EnumTransactionType NOT NULL,
);

ALTER TABLE
    "account"
ADD
    CONSTRAINT PK_account PRIMARY KEY (account_id);

ALTER TABLE
    "user"
ADD
    CONSTRAINT PK_user PRIMARY KEY (user_id);

ALTER TABLE
    "person"
ADD
    CONSTRAINT PK_person PRIMARY KEY (person_id);

ALTER TABLE
    "transactions"
ADD
    CONSTRAINT PK_transaction PRIMARY KEY (transaction_id);

ALTER TABLE
    "user"
ADD
    CONSTRAINT FK_account_user FOREIGN KEY (account_id) REFERENCES "account"(account_id);

ALTER TABLE
    person
ADD
    CONSTRAINT FK_user_person FOREIGN KEY (user_id) REFERENCES "user"(user_id);

ALTER TABLE
    "transactions"
ADD
    CONSTRAINT FK_account_sender_transactions FOREIGN KEY (account_sender) REFERENCES "account"(account_id);

ALTER TABLE
    "transactions"
ADD
    CONSTRAINT FK_account_receiver_transactions FOREIGN KEY (account_receiver) REFERENCES "account"(account_id);