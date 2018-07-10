import React from 'react';
import { Form, FormControl, ControlLabel, Row, Button, Col } from 'react-bootstrap';
import axios from 'axios';

export default class GameParams extends React.Component {
  
  constructor() {
    super();

    this.state = {
      generators: [],
      fillFactors: [],
      width: 10,
      height: 10,
      fillFactor: .5
    };
  }

  componentDidMount() {
    axios.get(`https://localhost:5001/api/generators`)
      .then(res => {
        const generators = res.data.map (obj => obj);
        this.setState({ generators: generators });
      });

      axios.get(`https://localhost:5001/api/fillfactor`)
      .then(res => {
        const fillFactors = res.data.map (obj => obj);
        this.setState({ fillFactors: fillFactors });
      });
  }

  render() {
    return (
      <Form componentClass="form-horozontal">
        <h2>Game Parameters <small>Enter game values here</small></h2>
          <ControlLabel>Dimensions (width x height)</ControlLabel>
          <Row>
            <Col xs={2} md={2}>
              <FormControl
                type="text"
                placeholder="Width" 
                size="sm"
                value={this.state.width}/>
            </Col>
            <Col xs={2} md={2}>
              <FormControl 
                type="text" 
                placeholder="Height" 
                size="sm"
                value={this.state.height} />
            </Col>
          </Row>
<br />
          <Row>
          <Col xs={2} md={2}>
              <ControlLabel>Fill Factor</ControlLabel>
              <FormControl componentClass="select" placeholder="template">
                {this.state.fillFactors.map(ff => 
                  <option value="ff}">{ff}</option>
                )}
              </FormControl>
            </Col>
          </Row>
          <br />

          <Row> 
            <Col xs={4} md={4}>
              <ControlLabel>Starting Template</ControlLabel>
              <FormControl componentClass="select" placeholder="template">
                <option value="">Random</option>
                {this.state.generators.map(generator => 
                  <option value="{generator.key}">{generator.value}</option>
                )}
              </FormControl>
            </Col>
          </Row>
          <br />
    
          <Row>
            <Col xs={1} md={1} xsOffset={3} >
              <Button bsStyle="primary">Go!</Button>
            </Col>
          </Row>
      </Form>
    )
  }
}