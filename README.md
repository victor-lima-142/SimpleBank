
# SimpleBank

A simple bank structure made with postgreSQL and .NET Core (C#) 8

## Database Overview
The database environment is based on four main tables: **accounts**, **users**, **persons** and **transactions**.

Using concepts of heritage we have in all relationships a one to one scenario:

- One **user**  Belongs to One **account**  (1:1)
- One **person** Belongs to One **user** (1:1)
- One **transaction** Belongs to One **account** in column *account_sender* (1:1) and the same happens with *account_receiver* (1:1) column.

With account_sender and account_receiver we've got all user, person and account information (It's happen across the keys relationship - primary/foreign key).

### Tables

#### Account Table (accounts)
This database entity have 8 columns:
 1. **account_id:** integer not null (primary key)
 2. **agency:** string not null
 3. **number:** string not null
 4. **starting_capital:** double not null (default 0.0)
 5. **balance:** double not null (default 0.0)
 6. **created_at:** date not null default NOW()
 7. **updated_at:** date not null default NOW()
 8. **deleted_at:** date nullable

#### User Table (users)
This database entity have 7 columns:
 1. **user_id:** integer not null (primary key)
 2. **email:** string not null
 3. **password:** string not null
 4. **account_id:** bigint not null unique (foreign key)
 5. **created_at:** date not null default NOW()
 6. **updated_at:** date not null default NOW()
 7. **deleted_at:** date nullable

#### Person Table (persons)
This database entity have 8 columns:
 1. **person_id:** integer not null (primary key)
 2. **name:** string not null
 3. **last_name:** string not null
 4. **tax_id:** string not null unique
 5. **birthday:** date not null
 6. **user_id** bigint not null  (foreign key)
 7. **created_at:** date not null default NOW()
 8. **updated_at:** date not null default NOW()
 9. **deleted_at:** date nullable

#### Transaction Table (transactions)
This database entity have 7 columns:
 1. **transaction_id:** integer not null (primary key)
 2. **date_transaction:** date not null default NOW()
 3. **account_sender:** bigint not null  (foreign key)
 4. **account_receiver:** bigint not null  (foreign key)
 5. **transaction_value:** double not null
 6. **transaction_type:** EnumTransactionType not null
 -- EnumTransactionType: **('Pix', 'Transference', 'TED', 'DOC')**

