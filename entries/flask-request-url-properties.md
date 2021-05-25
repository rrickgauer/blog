This post is a table containing some useful [Flask Request](https://flask.palletsprojects.com/en/2.0.x/api/#flask.Request) properties that contain information about the URL.

## Properties

The table below will use the following url as the example:

```http
https://example.com/search/products?name=Ryan&age=25
```

---

Property         | Value
--- | ---
`base_url`     | https&#65279;://example.com/search/products
`full_path`    | /search/products?name=Ryan&age=25
`host_url`     | https&#65279;://example.com/
`host`         | example&#46;com
`path`         | /search/products
`query_string` | b'name=Ryan&age=25'
`remote_addr`  | 11.22.33.66 (the client's IP address)
`url`          | https&#65279;://example.com/search/products?name=Ryan&age=25
`url_root`     | https&#65279;://example.com/
`url_rule`     | /search/products