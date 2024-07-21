import React from 'react';
import './App.css';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import { Container } from 'react-bootstrap';
import Header from './components/Header';
import Home from './pages/Home';
import Translators from './pages/Translators';

const App: React.FC = () => (
  <Container>
    <Header/>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/translators" element={<Translators />} />
      </Routes>
    </BrowserRouter>
  </Container>
)

export default App;