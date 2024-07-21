import React, { lazy } from "react"
import Home from "./pages/Home"
import Translators from "./pages/Translators"

const routes = [
    { path: "/", element: <Home/> },
    { path: "translators", element: <Translators/> },
]

export default routes