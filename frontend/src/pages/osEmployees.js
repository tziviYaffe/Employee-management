
import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  getOsEmployeesThunk,
  deleteEmployeeThunk,
} from "../redux/thunks/employeesThunk";
import EmployeesTable from "../components/EmployeesTable";
import AddEmployeeButton from "../components/AddEmployeeButton";
import "../components/table.css";

const OsEmployees = () => {
  const dispatch = useDispatch();
  const osEmployees = useSelector((state) => state.employees.osEmployees);

  useEffect(() => {
    dispatch(getOsEmployeesThunk());
  }, [dispatch]);


  const handleEdit = (id) => {
    console.log("Editing OS employee with ID:", id);
  };

  const handleDelete = (id) => {
    if (window.confirm("Are you sure you want to delete this OS employee?")) {
      dispatch(deleteEmployeeThunk(id));
    }
  };

  return (
    <div>
      <div className="header">
        <h1 className="title">All OS Employees</h1>
        <AddEmployeeButton />
      </div>
      <EmployeesTable
        employees={osEmployees}
        onEdit={handleEdit}
        onDelete={handleDelete}
      />
    </div>
  );
};

export default OsEmployees;
