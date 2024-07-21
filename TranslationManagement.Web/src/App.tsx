import React from 'react';
import './App.css';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import routes from './routes';
import Layout from './components/Layout';
import Page404 from './components/Page404';

const App: React.FC = () => (
  <RouterProvider router={createBrowserRouter([
  {
    element: <Layout />,
    errorElement: <Page404 />,
    children: routes
  },
  ])} />
)
export default App;