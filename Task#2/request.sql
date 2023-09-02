create table products (
    id int primary key
  , name varchar(20)
);

create table categories (
    id int primary key
  , name varchar(20)
);

create table productCategory(
    productId
  , categoryId
  , primary key (productId, categoryId)
);

insert into products
values
(1, "p_1"),
(2, "p_2"),
(3, "p_3"),
(4, "p_4");

insert into categories
values
(1, "c_1"),
(2, "c_2"),
(3, "c_3"),
(4, "c_4");

insert into productCategory
values
(1,1),
(1,2),
(1,3),
(2,1),
(2,3),
(4,3);

select
    p.name
  , c.name
from
  products as p
  left join productCategory as pc
  on p.id = pc.productId
  left join categories as c
  on pc.categoryId = c.id
;