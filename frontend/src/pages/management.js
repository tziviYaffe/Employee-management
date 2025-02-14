import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getManagersThunk, deleteEmployeeThunk } from "../redux/thunks/employeesThunk";
import EmployeesTable from "../components/EmployeesTable";
import AddEmployeeButton from "../components/AddEmployeeButton";
import "../components/table.css";

const Management = () => {
  const dispatch = useDispatch();
  const managers = useSelector((state) => state.employees.managers);

  useEffect(() => {
    dispatch(getManagersThunk());
  }, [dispatch]);


  const handleEdit = (id) => {
    console.log("Editing manager with ID:", id);
  };

  const handleDelete = (id) => {
    if (window.confirm("Are you sure you want to delete this manager?")) {
      dispatch(deleteEmployeeThunk(id));
    }
  };

  return (
    <div>
      <div className="header">
        <h1 className="title">All Managers</h1>
        <AddEmployeeButton />
      </div>
      <EmployeesTable employees={managers} onEdit={handleEdit} onDelete={handleDelete} />
    </div>
  );
};

export default Management;

