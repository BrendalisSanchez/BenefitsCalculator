import React, { useState } from "react";
import Header from "./Header";
import Footer from "./Footer";
import Employee from "./Employee";
import CreateEmployee from "./CreateEmployee";

function App() {
  const [employee, setEmployee] = useState([]);

  function addEmployee(newEmployee) {
    setEmployee((prevNotes) => {
      return [...prevNotes, newEmployee];
    });
  }

  function editEmployee(id) {
    setEmployee((prevNotes) => {
      return prevNotes.filter((employeeItem, index) => {
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
