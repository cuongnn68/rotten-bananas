import logo from './logo.svg';
import './App.css';
import {Link, Outlet} from "react-router-dom";
import NavBar from './components/NavBar';

function App() {
  return (
    <div className='App'>
      <NavBar />
      <div className="Content">
        <Outlet />
      </div>
    </div>
  );
}

export default App;
