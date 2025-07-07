import React, { Component } from "react";

class Greet extends Component {
  constructor(props) {
    super(props);

    this.state = {
      name: "riya",
      total: 0,
    };
  }

  handleClick = () => {
    this.setState({ total: this.state.total + 1 });
  };

  render() {
    return (
      <>
        <div style={{ textAlign: "center", marginTop: "20px" }}>
          <h1> Hello, {this.state.name}!</h1>
          <p> You clicked {this.state.total}</p>
          <button onClick={this.handleClick}> click me</button>
        </div>
      </>
    );
  }
}

export default Greet;
