import React, { useState } from "react";

function CreateEmployee(props) {
  const [employee, setEmployee] = useState({
    employeeNumber: "",
    firstName: "",
    middleName: "",
    lastName: "",
    dependents: "",
    paycheck: "",
    status: ""
  });

  function handleChange(event) {
    const { name, value } = event.target;

    setEmployee((prevEmployee) => {
      return {
        ...prevEmployee,
        [name]: value
      };
    });
  }

  function submitEmployee(event) {
    props.onAdd(employee);
    setEmployee({
      employeeNumber: "",
      firstName: "",
      middleName: "",
      lastName: "",
      dependents: "",
      paycheck: "",
      status: ""
    });
    event.preventDefault();
  }

  return (
    <div>
      <form>
        <input
          name="employeeNumber"
          onChange={handleChange}
          value={employee.employeeNumber}
          placeholder="Employee Number"
        />
        <input
          name="firstName"
          onChange={handleChange}
          value={employee.firstName}
          placeholder="First Name"
        />{" "}
        <input
          name="middleName"
          onChange={handleChange}
          value={employee.middleName}
          placeholder="Middle Name"
        />{" "}
        <input
          name="lastName"
          onChange={handleChange}
          value={employee.lastName}
          placeholder="Last Name"
        />{" "}
        <input
          name="dependents"
          onChange={handleChange}
          value={employee.dependents}
          placeholder="Dependents"
        />{" "}
        <input
          name="paycheck"
          onChange={handleChange}
          value={employee.paycheck}
          placeholder="Paycheck"
        />{" "}
        <input
          name="status"
          onChange={handleChange}
          value={employee.status}
          placeholder="Status"
        />
        <button onClick={submitEmployee}>Add</button>
      </form>
    </div>
  );
}

export default CreateEmployee;
