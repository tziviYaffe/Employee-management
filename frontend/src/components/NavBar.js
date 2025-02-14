import React from "react";
import { NavLink } from "react-router-dom";
import "../styles/navbar.css"; // חיבור לקובץ ה-CSS

const Navbar = () => {
  return (
    <nav className="navbar">
      <div className="logo">S.A.D.C</div>
      <ul className="nav-links">
        <li>
          <NavLink to="home" className={({ isActive }) => (isActive ? "active" : "")}>
            Home
          </NavLink>
        </li>
        <li>
          <NavLink to="employees" className={({ isActive }) => (isActive ? "active" : "")}>
            All Employees
          </NavLink>
        </li>
        <li>
          <NavLink to="management" className={({ isActive }) => (isActive ? "active" : "")}>
            Management Employees
          </NavLink>
        </li>
        <li>
          <NavLink to="osEmployees" className={({ isActive }) => (isActive ? "active" : "")}>
            OS Employees
          </NavLink>
        </li>
      </ul>
    </nav>
  );
};

export default Navbar;
