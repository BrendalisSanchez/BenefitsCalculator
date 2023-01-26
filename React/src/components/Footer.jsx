import React from "react";

function Footer() {
  const year = new Date().getFullYear();
  return (
    <footer>
      <p>Employee Benefits Calculator{year}</p>
    </footer>
  );
}

export default Footer;
