const express = require("express")
const app = express()
const cors = require("cors")
const { fetchUrlContent } = require("./fetch-url-content")

NODE_TLS_REJECT_UNAUTHORIZED = '0'

app.use(cors())
app.use(express.urlencoded(({ extended: true })))

app.post("/", async function (req, res) {
    const url = req.body.url
    const content = await fetchUrlContent(url)

    res.send(content)
})

module.exports = app