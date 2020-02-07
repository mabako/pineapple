import React, { Component } from 'react';

interface ILocalState {
  existingSpaces: ISpaceList,
  loading: boolean
}

interface ISpaceList {
  spaces: string[]
}

export class ListPages extends Component<{}, ILocalState> {
  static displayName = ListPages.name;


  constructor(props: any) {
    super(props);
    this.state = { existingSpaces: { spaces: [] }, loading: true };
  }

  componentDidMount(): void {
    this.populateSpaces();
  }

  async populateSpaces() {
    const response = await fetch("$/api/v1/spaces");
    const data = await response.json();
    this.setState({ existingSpaces: data, loading: false });
  }

  render () {
    let contents = this.state.loading
      ? <p><em>Loading&ellip;</em></p>
      : ListPages.renderSpaces(this.state.existingSpaces.spaces);

    return (
      <div>
        <h1>Welcome!</h1>
        <p>Pick a space to start.</p>
        {contents}
      </div>
    );
  }

  static renderSpaces(spaces: string[]) {
    return (
      <ul>
        {spaces.map(space =>
          <li key={space}>{space}</li>
        )}
      </ul>
    );
  }
}
