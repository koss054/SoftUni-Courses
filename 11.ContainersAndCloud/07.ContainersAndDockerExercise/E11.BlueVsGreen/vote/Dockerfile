# Using official python runtime base image
FROM python

# Set the application directory
WORKDIR /app

# Install our requirements.txt
RUN pip install Flask Redis gunicorn

# Copy our code from the current folder to /app inside the container
COPY vote/. .

# Make port 80 available for links and/or publish
EXPOSE 80

# Define our command to be run when launching the container
ENTRYPOINT python app.py
