import React from "react";
import { useNavigate } from "react-router-dom";

const AddEmployeeButton = () => {
  const navigate = useNavigate();

  return (
    <button
      className="add-employee-btn"
      onClick={() => navigate("/add-employee")}
    >
      + Add Employee
    </button>
  );
};

export default AddEmployeeButton;
