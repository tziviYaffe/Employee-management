import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  addEmployeeThunk,
  getEmployeesThunk,
} from "../redux/thunks/employeesThunk";
import { getRolesThunk } from "../redux/thunks/rolesThunk";
import { useNavigate } from "react-router-dom";
import "./styles/form.css";

const AddEmployee = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const roles = useSelector((state) => state.roles.roles);

  const [formData, setFormData] = useState({
    name: "",
    idNumber: "",
    roleName: "",
    managerName: "",
  });

  const [error, setError] = useState("");

  // קריאה לשרת להבאת התפקידים בטעינת העמוד
  useEffect(() => {
    dispatch(getRolesThunk());
  }, [dispatch]);

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(""); // לנקות שגיאות קודמות

    //  ולידציה בצד הלקוח
    if (!formData.name || !formData.idNumber || !formData.roleName) {
      setError("יש למלא את כל השדות (חוץ משם מנהל)");
      return;
    }
    if (!/^\d{9}$/.test(formData.idNumber)) {
      setError("תעודת זהות חייבת להיות באורך של 9 ספרות");
      return;
    }

    //  שליחת הנתונים לשרת
    const result = await dispatch(addEmployeeThunk(formData));

    if (result.success) {
      alert("העובד נוסף בהצלחה!");
      navigate("/employees");
      //  שליפת רשימת העובדים מחדש כדי לעדכן את הנתונים ב-Redux
     // await dispatch(getEmployeesThunk());
      //  ניווט חזרה לעמוד כל העובדים
      
    } else {
      setError(result.message);
    }
  };

  return (
    <div className="form-container">
      <h2>Add New Employee</h2>

      {/* הצגת הודעת שגיאה אם קיימת */}
      {error && <p className="error-message">{error}</p>}

      <form onSubmit={handleSubmit}>
        <label>Name:</label>
        <input
          type="text"
          name="name"
          value={formData.name}
          onChange={handleChange}
          required
        />

        <label>ID Number:</label>
        <input
          type="text"
          name="idNumber"
          value={formData.idNumber}
          onChange={handleChange}
          required
        />

        <label>Role:</label>
        <select
          name="roleName"
          value={formData.roleName}
          onChange={handleChange}
          required
        >
          <option value="" disabled>
            Choose a role
          </option>
          {roles.map((role) => (
            <option key={role.id} value={role.name}>
              {role.name}
            </option>
          ))}
        </select>

        <label>Manager:</label>
        <input
          type="text"
          name="managerName"
          value={formData.managerName}
          onChange={handleChange}
        />

        <button type="submit" className="submit-btn">
          Add Employee
        </button>
      </form>
    </div>
  );
};

export default AddEmployee;
