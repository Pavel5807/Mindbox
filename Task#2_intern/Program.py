import pyspark.sql

spark = pyspark.sql.SparkSession.builder.master("local").getOrCreate()

df_products = spark.createDataFrame(
    [
        {"id": 1, "name": "p_1"},
        {"id": 2, "name": "p_2"},
        {"id": 3, "name": "p_3"},
        {"id": 4, "name": "p_4"},
    ]
)
df_products_categories = spark.createDataFrame(
    [
        {"id_product": 1, "id_category": 1},
        {"id_product": 1, "id_category": 2},
        {"id_product": 1, "id_category": 3},
        {"id_product": 1, "id_category": 4},
        {"id_product": 3, "id_category": 1},
        {"id_product": 3, "id_category": 2},
        {"id_product": 3, "id_category": 4},
        {"id_product": 4, "id_category": 2},
        {"id_product": 4, "id_category": 3},
        {"id_product": 4, "id_category": 4},
    ]
)
df_categories = spark.createDataFrame(
    [
        {"id": 1, "name": "c_1"},
        {"id": 2, "name": "c_2"},
        {"id": 3, "name": "c_3"},
        {"id": 4, "name": "c_4"},
    ]
)

spark.sql(
    """
    select
          p.name as product
        , c.name as category
    from
        {products} p
        left join {products_categories} pc
        on p.id = pc.id_product
        left join {categories} c
        on pc.id_category = c.id
    order by
          p.name
        , c.name""",
    products=df_products,
    products_categories=df_products_categories,
    categories=df_categories,
).show()
