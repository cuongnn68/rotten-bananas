import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Route, Routes } from "react-router-dom";
import Expenses from "./pages/expenses.js";
import Invoices from "./pages/invoices.js";
import Invoice from './pages/invoise.js';
import HomePage from './components/home/HomePage';
import MoviePage from './components/movie/MoviePage';
import SearchPage from './components/search/searchPage';

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<App />}>
          <Route index element={<HomePage />}/>
          <Route path="home" element={<HomePage />}/>
          <Route path="movie" element={<MoviePage />} />
          <Route path="search" element={<SearchPage />} />
        </Route>
        <Route path="*" element={"Page not found"}/>
      </Routes>
      {/* <Routes>
        <Route path="/" element={<App />} >
          <Route path="expenses" element={<Expenses />} />
          <Route path="invoices" element={<Invoices />}>
            <Route
              index
              element={
                <main style={{ padding: "1rem" }}>
                  <p>Select an invoice</p>
                </main>
              }
            />
            <Route path=':invoice' element={<Invoice />} />
          </Route>
        </Route>
        <Route
          path="*"
          element={
            <main style={{ padding: "1rem" }}>
              <p>There's nothing here!</p>
            </main>
          }
        />
      </Routes> */}
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
