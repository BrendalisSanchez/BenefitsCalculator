import React from "react";

function Employee(props) {
  function handleClick() {
    props.onDelete(props.id);
  }

  return (
    <div className="employee">
      <h1>{props.employeeNumber}</h1>
      <p>{props.firstName}</p>
      <p>{props.middleName}</p>
      <p>{props.lastName}</p>
      <p>{props.dependents}</p>
      <p>{props.paycheck}</p>
      <p>{props.status}</p>
      <button onClick={handleClick}>DELETE</button>
    </div>
  );
}

export default Employee;
