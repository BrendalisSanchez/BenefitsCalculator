import React, { useState } from "react";
import Header from "./Header";
import Footer from "./Footer";
import Employee from "./employees/Employee";
import CreateEmployee from "./employees/CreateEmployee";

function App() {
  const [employee, setEmployee] = useState([]);

  function addEmployee(newEmployee) {
    setEmployee((prevEmployees) => {
      return [...prevEmployees, newEmployee];
    });
  }

  function editEmployee(id) {
    setEmployee((prevEmployees) => {
      return prevEmployees.filter((employeeItem, index) => {
        return index !== id;
      });
    });
  }

  return (
    <div>
      <Header />
      <CreateEmployee onAdd={addEmployee} />
      {employee.map((employeeItem, index) => {
        return (
          <Employee
            key={index}
            id={index}
            employeeNumber={employeeItem.employeeNumber}
            firstName={employeeItem.firstName}
            middleName={employeeItem.middleName}
            lastName={employeeItem.lastName}
            dependents={employeeItem.dependents}
            paycheck={employeeItem.paycheck}
            status={employeeItem.status}
            onEditEmployee={editEmployee}
          />
        );
      })}
      <Footer />
    </div>
  );
}

export default App;
