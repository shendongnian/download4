doubleJumpReady = false;
Variable. To fix this simply change the jump code to:
protected void Jump()
{
    if (grounded)
    {
        rb.AddForce(Vector2.up * jumpForce);
        grounded = false;
        doubleJumpReady = true;
    }
    else if (!grounded && doubleJumpReady)
    {
        rb.AddForce(Vector2.up * jumpForce);
        doubleJumpReady = false;
    }
}
Hope it works ;).
EDIT:
grounded is set by overlapping spheres. Therefore no need to set it here.
Use this code and press your jump btn 2 times and see if the Debug.Log message shows up. Also, your player ID (idx is not needed.) As far as i can see your script is attached two to different objects. Therefore their variables are not shared anyways.
        protected void Jump()
        {
            if (grounded)
            {
                rb.AddForce(Vector2.up * jumpForce);
                doubleJumpReady = true;
            }
            else if (!grounded && doubleJumpReady)
            {
                rb.AddForce(Vector2.up * jumpForce);
                doubleJumpReady = false;
                Debug.Log("I am double jumping");
            }
        } 
