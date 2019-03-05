import React from 'react';

class SectionHeader extends React.Component {
    render() {
        return (
            <div className="title-wrap d-flex justify-content-between">
                <div className="title-box">
                    <h2 className="title-a">{this.props.title}</h2>
                </div>
            </div>
        );
    }
};

export default SectionHeader;