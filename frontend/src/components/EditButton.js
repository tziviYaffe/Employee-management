import React from "react";

const EditButton = ({ onClick }) => {
  return (
    <button className="edit-btn" onClick={onClick}>
      Edit
    </button>
  );
};

export default EditButton;
