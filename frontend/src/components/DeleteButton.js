import React from "react";

const DeleteButton = ({ onClick }) => {
  return (
    <button className="delete-btn" onClick={onClick}>
      Delete
    </button>
  );
};

export default DeleteButton;
