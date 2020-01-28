import os
import boto3


def get_groups(event, context):

    aws_region = os.environ['AWS_REGION']
    dynamodb = boto3.resource('dynamodb', region_name=aws_region)
    table = dynamodb.Table('SystembolagetReleases')
    groups = []
    return {
        'data': groups
    }
