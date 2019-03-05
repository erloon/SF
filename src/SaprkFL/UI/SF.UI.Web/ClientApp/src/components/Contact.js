import React from 'react';
import SectionHeader from './Layout/SectionHeader';
class Contact extends React.Component {
    render() {
        return (
            <section className="section-services section-t8">
                <div className="container">
                    <div className="row">
                        <div className="col-md-12">
                            <div className="title-wrap d-flex justify-content-between">
                                <SectionHeader title="Kontakt" />
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        )
    }
}

export default Contact;