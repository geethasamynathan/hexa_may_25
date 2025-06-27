import React, { useState } from "react";

const EventHandling = () => {
  return (
    <div>
      <select onChange={(e) => alert("selected options are " + e.target.value)}>
        <option value="">Select the option</option>
        <option value="Angular">Angular</option>
        <option values="React">React</option>
        <option value="Azure">Azure</option>
      </select>
    </div>
  );
};

export default EventHandling;
