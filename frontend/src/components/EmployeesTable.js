
import React, { useState } from "react";
import EditButton from "./EditButton";
import DeleteButton from "./DeleteButton";
import EditEmployeeModal from "./EditEmployeeModal";
import "./table.css";

const EmployeesTable = ({ employees, onEdit, onDelete }) => {
  const [selectedEmployee, setSelectedEmployee] = useState(null);

  return (
    <div>
      <table className="employees-table">
        <thead>
          <tr>
            <th>שם</th>
            <th>תעודת זהות</th>
            <th>תפקיד</th>
            <th>מנהל</th>
            <th>פעולות</th>
          </tr>
        </thead>
        <tbody>
          {employees.map((employee) => (
            <tr key={employee.id}>
              <td>{employee.name}</td>
              <td>{employee.idNumber}</td>
              <td>{employee.roleName}</td>
              <td>{employee.managerName || ""}</td>
              <td>
                <EditButton onClick={() => setSelectedEmployee(employee)} />
                <DeleteButton onClick={() => onDelete(employee.id)} />
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {selectedEmployee && (
        <EditEmployeeModal
          employee={selectedEmployee}
          onClose={() => setSelectedEmployee(null)}
        />
      )}
    </div>
  );
};

export default EmployeesTable;
