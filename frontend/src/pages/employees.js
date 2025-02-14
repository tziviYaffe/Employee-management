import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getEmployeesThunk, deleteEmployeeThunk } from "../redux/thunks/employeesThunk";
import EmployeesTable from "../components/EmployeesTable";
import AddEmployeeButton from "../components/AddEmployeeButton";
import "../components/table.css";

const Employees = () => {
  const dispatch = useDispatch();
  const employees = useSelector((state) => state.employees.employees);

  useEffect(() => {
    dispatch(getEmployeesThunk());
  }, [dispatch]);


  useEffect(() => {
  }, [employees]); 

  const handleEdit = (id) => {
    console.log("Editing employee with ID:", id);
  };

  const handleDelete = (id) => {
    if (window.confirm("Are you sure you want to delete this employee?")) {
      dispatch(deleteEmployeeThunk(id));
    }
  };

  return (
    <div>
      <div className="header">
        <h1 className="title">All Employees</h1>
        <AddEmployeeButton />
      </div>
      <EmployeesTable employees={employees} onEdit={handleEdit} onDelete={handleDelete} />
    </div>
  );
};

export default Employees;


