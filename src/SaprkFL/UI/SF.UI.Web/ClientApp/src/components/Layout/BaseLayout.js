import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import NavBar from './NavBar';

const styles = theme => ({
  root: {
    flexGrow: 1,
  },
  paper: {
    padding: theme.spacing.unit * 2,
    textAlign: 'center',
    color: theme.palette.text.secondary,
  },
});

function BaseLayout(props) {
  const { classes } = props;

  return (
    <div className={classes.root}>
      <NavBar />
      <Grid container spacing={24}>
        <Grid item={24}>
          {props.children}
        </Grid>
      </Grid>
    </div>
  )
}

BaseLayout.propTypes = {
  classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(BaseLayout);