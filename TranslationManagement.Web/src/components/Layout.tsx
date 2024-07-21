
import { Outlet } from "react-router-dom"
import { Suspense } from "react"
import { Container } from "react-bootstrap"
import Header from "./Header"

export default function Layout() {
    return (
        <Container>
            <Header />
            <main>
                <Suspense fallback={<div>Loading...</div>}>
                    <Outlet />
                </Suspense>
            </main>
        </Container>
    )
}