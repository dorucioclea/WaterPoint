var ItemList = React.createClass({    
    render: function () {
        var items = this.props.data.map(function (item) {
            return (
                <tr>
                    <td>{item.firstName}</td>
                    <td>{item.lastName}</td>
                </tr>
            );
        });

        return (<tbody>{items}</tbody>);
    }
});