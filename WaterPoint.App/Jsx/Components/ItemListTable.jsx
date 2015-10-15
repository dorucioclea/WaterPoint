var ItemListTable = React.createClass({
    getInitialState: function () {
        return {
            data: this.props.initialData
        };
    },

    render: function () {
        debugger;
        return (
            <div>
                <table>
                    <ItemList data={this.state.data} />
                </table>
            </div>
        );
    }
});
