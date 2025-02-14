import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { updateEmployeeThunk } from "../redux/thunks/employeesThunk";
import "./modal.css";

const EditEmployeeModal = ({ employee, onClose }) => {
  const dispatch = useDispatch();

  const [formData, setFormData] = useState({
    name: employee.name,
    idNumber: employee.idNumber, // תעודת זהות תוצג אך לא תהיה ניתנת לעריכה
    roleName: employee.roleName,
    managerName: employee.managerName || "",
  });

  const [error, setError] = useState("");

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError("");

    if (!formData.name || !formData.roleName) {
      setError("יש למלא את כל השדות!");
      return;
    }

    const result = await dispatch(updateEmployeeThunk(employee.id, formData));

    if (result?.success) {
      alert("פרטי העובד עודכנו בהצלחה!");
      onClose(); // סגירת המודאל
    } else {
      setError(result.message);
    }
  };

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2>עריכת עובד</h2>
        {error && <p className="error-message">{error}</p>}

        <form onSubmit={handleSubmit}>
          <label>שם:</label>
          <input type="text" name="name" value={formData.name} onChange={handleChange} required />

          <label>תעודת זהות:</label>
          <input type="text" name="idNumber" value={formData.idNumber} disabled />

          <label>תפקיד:</label>
          <input type="text" name="roleName" value={formData.roleName} onChange={handleChange} required />

          <label>מנהל:</label>
          <input type="text" name="managerName" value={formData.managerName} onChange={handleChange} />

          <button type="submit">שמור שינויים</button>
          <button type="button" onClick={onClose} className="close-btn">ביטול</button>
        </form>
      </div>
    </div>
  );
};

export default EditEmployeeModal;
