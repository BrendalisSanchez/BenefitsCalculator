import React, { useState } from "react";

function EditEmployee(props) {
  const [employee, setEmployee] = useState({
    title: "",
    content: "",
  });

  function handleChange(event) {
    const { name, value } = event.target;

    setEmployee((prevEmployee) => {
      return {
        ...prevEmployee,
        [name]: value,
      };
    });
  }

  function submitEmployee(event) {
    props.onAdd(employee);
    setemployee({
      title: "",
      content: "",
    });
    event.preventDefault();
  }

  return (
    <div>
      <form>
        <input
          name="title"
          onChange={handleChange}
          value={employee.title}
          placeholder="Title"
        />
        <textarea
          name="content"
          onChange={handleChange}
          value={employee.content}
          placeholder="Take a employee..."
          rows="3"
        />
        <button onClick={submitEmployee}>Add</button>
      </form>
    </div>
  );
}

export default EditEmployee;
