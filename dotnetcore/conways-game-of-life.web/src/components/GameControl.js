import React from 'react';
import { Checkbox, Row, Button, Col } from 'react-bootstrap';

export default class GameControls extends React.Component {
  constructor() {
    super();

    this.state = {
      autoTick: false
    };
  }

  handleChangeAutoTick() {
    this.setState({ autoTick: !this.state.autoTick });
  }

  render() {
    return (
      <div>
        <Row>
          <Col xs={3} md={3}>
            <Checkbox
              type="text"
              placeholder="Width"
              size="sm"
              checked={this.state.autoTick}
              onClick={() => this.handleChangeAutoTick()}
            >
              Auto-tick Game
            </Checkbox>
          </Col>
          <Col xs={1} md={1}>
            <Button bsStyle="primary" disabled={this.state.autoTick}>
              Tick
            </Button>
          </Col>
        </Row>
      </div>
    );
  }
}
